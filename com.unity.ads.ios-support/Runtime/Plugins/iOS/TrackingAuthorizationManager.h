#import <Foundation/Foundation.h>

@interface TrackingAuthorizationManager : NSObject

typedef void (*callbackFunc)();

+ (TrackingAuthorizationManager *)sharedInstance;

- (BOOL)isAvailable;
- (void)trackingAuthorizationRequest:(callbackFunc) callback;
- (NSUInteger)getTrackingAuthorizationStatus;
@end
