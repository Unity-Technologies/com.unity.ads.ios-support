#import <Foundation/Foundation.h>
#import "SkAdNetworkManager.h"

extern void InterfaceSkAdNetworkUpdateConversionValue(NSInteger conversionValue) {
    [[SkAdNetworkManager sharedInstance] updateConversionValue:(NSInteger)conversionValue];
}

extern void InterfaceSkAdNetworkRegisterAppForNetworkAttribution() {
    [[SkAdNetworkManager sharedInstance] registerAppForAdNetworkAttribution];
}
