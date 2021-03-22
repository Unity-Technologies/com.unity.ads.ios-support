#import <Foundation/Foundation.h>
#import "TrackingAuthorizationManager.h"


extern void InterfaceTrackingAuthorizationRequest(callbackFunc callback) {
    [[TrackingAuthorizationManager sharedInstance] trackingAuthorizationRequest:callback];
}

extern NSUInteger InterfaceGetTrackingAuthorizationStatus() {
    return [[TrackingAuthorizationManager sharedInstance] getTrackingAuthorizationStatus];
}
