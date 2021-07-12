#import "SkAdNetworkManager.h"
#import <Foundation/Foundation.h>
#import <dlfcn.h>
#import <objc/runtime.h>
#import <sys/utsname.h>


@interface SkAdNetworkManager ()
@property (strong, nonatomic) Class SkAdNetworkClass;
@end

@implementation SkAdNetworkManager

- (instancetype)init {
    if (self = [super init]) {
        if (![SkAdNetworkManager loadFramework]) {
            NSLog(@"Can't load StoreKit DLL");
        }
        self.SkAdNetworkClass = NSClassFromString(@"SKAdNetwork");
    }
    return self;
}

+ (SkAdNetworkManager *)sharedInstance {
    static SkAdNetworkManager *instance = nil;
    static dispatch_once_t token;

    dispatch_once(&token, ^{
      instance = [[SkAdNetworkManager alloc] init];
    });
    return instance;
}

- (void)updateConversionValue:(NSInteger)conversionValue {
    if (!self.isAvailable) {
        NSLog(@"updateConversionValue::Not properly initialized");
        return;
    }

    id target = self.SkAdNetworkClass;
    SEL selector = NSSelectorFromString(@"updateConversionValue:");
    NSMethodSignature * signature = [target methodSignatureForSelector:selector];
    if (signature) {
        NSLog(@"updateConversionValue::Invoking conversionValue=%ld", conversionValue);
        NSInvocation * invocation = [NSInvocation invocationWithMethodSignature:signature];
        invocation.target = target;
        invocation.selector = selector;
        [invocation setArgument:&conversionValue atIndex:2];
        [invocation invoke];
    } else {
        NSLog(@"updateConversionValue::Unknown method signature");
    }
}

- (void)registerAppForAdNetworkAttribution {
    if (!self.isAvailable) {
        NSLog(@"registerAppForAdNetworkAttribution::Not properly initialized");
        return;
    }

    id target = self.SkAdNetworkClass;
    SEL selector = NSSelectorFromString(@"registerAppForAdNetworkAttribution");
    NSMethodSignature * signature = [target methodSignatureForSelector:selector];
    if (signature) {
        NSLog(@"registerAppForAdNetworkAttribution::Invoking");
        NSInvocation * invocation = [NSInvocation invocationWithMethodSignature:signature];
        invocation.target = target;
        invocation.selector = selector;
        [invocation invoke];
    } else {
        NSLog(@"registerAppForAdNetworkAttribution::Unknown method signature");
    }
}

- (BOOL)isAvailable {
    return self.SkAdNetworkClass != nil;
}

+ (BOOL)isFrameworkPresent {
    id attClass = objc_getClass("SKAdNetwork");

    if (attClass)
        return TRUE;

    return FALSE;
}

+ (BOOL)isDeviceSimulator {
    struct utsname systemInfo;
    uname(&systemInfo);

    NSString *model = [NSString stringWithCString:systemInfo.machine encoding:NSUTF8StringEncoding];
    if ([model isEqualToString:@"x86_64"] || [model isEqualToString:@"i386"])
        return TRUE;

    return FALSE;
}

+ (BOOL)loadFramework {
    NSString *frameworkLocation;

    if (![SkAdNetworkManager isFrameworkPresent]) {
        NSLog(@"StoreKit.framework is not present, trying to load it.");
        if ([SkAdNetworkManager isDeviceSimulator]) {
            NSString *frameworkPath = [[NSProcessInfo processInfo] environment][@"DYLD_FALLBACK_FRAMEWORK_PATH"];
            if (frameworkPath) {
                frameworkLocation = [NSString pathWithComponents:@[ frameworkPath, @"StoreKit.framework", @"StoreKit" ]];
            }
        } else {
            frameworkLocation = [NSString stringWithFormat:@"/System/Library/Frameworks/StoreKit.framework/StoreKit"];
        }
        dlopen([frameworkLocation cStringUsingEncoding:NSUTF8StringEncoding], RTLD_LAZY);

        if (![SkAdNetworkManager isFrameworkPresent]) {
            NSLog(@"StoreKit.framework still no present!");
            return FALSE;
        } else {
            NSLog(@"Successfully loaded StoreKit.framework");
            return TRUE;
        }
    } else {
        NSLog(@"StoreKit.framework already present");
        return TRUE;
    }
}

@end
