#import <Foundation/Foundation.h>
#import "TrackingAuthorizationManager.h"


extern void InterfaceTrackingAuthorizationRequest() {
    [[TrackingAuthorizationManager sharedInstance] trackingAuthorizationRequest];
}

extern NSUInteger InterfaceGetTrackingAuthorizationStatus() {
    return [[TrackingAuthorizationManager sharedInstance] getTrackingAuthorizationStatus];
}
