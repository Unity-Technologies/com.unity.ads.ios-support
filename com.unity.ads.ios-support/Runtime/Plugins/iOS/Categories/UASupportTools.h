#import <Foundation/Foundation.h>
NS_ASSUME_NONNULL_BEGIN

/**
    Macro that replaces boilerplate code like:
   @code

   if ([obj isKindOfClass: class]) {
     return obj;
   } else {
     return nil;
   }
 */
#define TYPECAST(obj, class) typecast(obj, class)

/**
    Macro that replaces  boilerplate code when calling super init
 */
#define SUPER_INIT self = [super init]; if (!self) { return nil; }


/**
    Convenience macro to check for condition and return nil if false
 */
#define GUARD_OR_NIL(condition) if (!condition) { return nil; }


_Nullable id uasupport_typecast(id obj, Class class);


NS_ASSUME_NONNULL_END