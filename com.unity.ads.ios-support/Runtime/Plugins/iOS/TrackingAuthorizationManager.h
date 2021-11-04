#import <Foundation/Foundation.h>

typedef void (*TrackingAuthorizationCompletion)(NSUInteger status);

@interface TrackingAuthorizationManager : NSObject

+ (TrackingAuthorizationManager *)sharedInstance;

- (BOOL)isAvailable;
- (void)trackingAuthorizationRequest:(TrackingAuthorizationCompletion)completion;
- (NSUInteger)getTrackingAuthorizationStatus;

@end
