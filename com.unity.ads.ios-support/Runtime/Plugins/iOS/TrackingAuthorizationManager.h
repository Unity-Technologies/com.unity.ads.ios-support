#import <Foundation/Foundation.h>

@interface TrackingAuthorizationManager : NSObject

+ (TrackingAuthorizationManager *)sharedInstance;

- (BOOL)isAvailable;
- (void)trackingAuthorizationRequest;
- (NSUInteger)getTrackingAuthorizationStatus;

@end
