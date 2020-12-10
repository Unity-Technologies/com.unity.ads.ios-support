#import <Foundation/Foundation.h>

@interface SkAdNetworkManager : NSObject

+ (SkAdNetworkManager *)sharedInstance;

- (BOOL)isAvailable;
- (void)updateConversionValue:(NSInteger)conversionValue;
- (void)registerAppForAdNetworkAttribution;

@end
