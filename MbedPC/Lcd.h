#ifndef LCDNAME
#define LCDNAME

#include "C12832.h"

/**
 * The Lcd class is used for implementing the lcd
 * The Lcd class inherits from the C12832 library
 */
class Lcd:public C12832{
    public:

        /**
         * The Lcd constuctor
         * @param mosi      the first pin of the lcd
         * @param sck       the second pin of the lcd
         * @param reset     the third pin of the lcd
         * @param a0        the fourth pin of the lcd
         * @param ncs       the fifth pin of the lcd
         */
        Lcd(PinName mosi, PinName sck, PinName reset, PinName a0, PinName ncs);
    
    private:

        /**
         * Variables of the type PinName used in the constructor
         */
        PinName mosi, sck, reset, a0, ncs;
};

#endif