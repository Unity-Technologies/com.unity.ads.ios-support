#import <Foundation/Foundation.h>
#import "TrackingAuthorizationManager.h"


extern void InterfaceTrackingAuthorizationRequest(TrackingAuthorizationCompletion completion) {
    [[TrackingAuthorizationManager sharedInstance] trackingAuthorizationRequest:completion];
}

extern NSUInteger InterfaceGetTrackingAuthorizationStatus() {
    return [[TrackingAuthorizationManager sharedInstance] getTrackingAuthorizationStatus];
}
