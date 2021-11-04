#import "UASupportTools.h"


_Nullable id uasupport_typecast(id obj, Class class) {
    if ([obj isKindOfClass: class]) {
        return obj;
    } else {
        return nil;
    }
}
