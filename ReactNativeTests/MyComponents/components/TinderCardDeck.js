import React from 'react';
import { View, Animated, PanResponder, Dimensions } from 'react-native';

const SCREEN_WIDTH = Dimensions.get('window').width;
const SWIPE_THRESHOLD = 0.25 * SCREEN_WIDTH;
const SWIPE_OUT_DURATION = 250;

export default class TinderCardDeck extends React.Component {
   constructor(props) {
      super(props);
      const _self = this;

      this.position = new Animated.ValueXY();

      this.panResponder = PanResponder.create({
         //executed anytime user taps on the screen, if true is returned then this inscance of pan responder will handle the tap event
         onStartShouldSetPanResponder: () => true,

         //once the responder is handling the gesture, this is the callback function of that gesture, called many times as long as user is dragging
         onPanResponderMove: (event, gesture) => { this.handleResponderMove(gesture); },

         //executed when lets go the screen
         onPanResponderRelease: (event, gesture) => { this.checkSwipeThresholdAndAnimate(gesture); }
      });
   }

   handleResponderMove(gesture) {
      this.position.setValue({ x: gesture.dx, y: gesture.dy });
   }

   checkSwipeThresholdAndAnimate(gesture) {
      if (gesture.dx > SWIPE_THRESHOLD) {
         this.swipeOutCard('right');
      }
      else if (gesture.dx < -SWIPE_THRESHOLD) {
         this.swipeOutCard('left');
      }
      else {
         this.resetCardPosition();
      }
   }

   swipeOutCard(direction) {
      Animated.timing(this.position, {
         toValue: { x: direction === 'right' ? SCREEN_WIDTH : -SCREEN_WIDTH, y: 0 },
         duration: SWIPE_OUT_DURATION
      }).start(() => {
         this.onSwipeComplete(direction);
      });
   }

   onSwipeComplete(direction) {
      const { onSwipeLeft, onSwipeRight } = this.props;

      //raise swipe callback
      if (direction === 'right' && onSwipeRight) {
         onSwipeRight();
      }
      else if (direction === 'left' && onSwipeLeft) {
         onSwipeLeft();
      }
   }

   resetCardPosition() {
      Animated.spring(this.position, {
         toValue: { x: 0, y: 0 }
      }).start();
   }

   getCardStyle() {
      const position = this.position;
      const rotate = position.x.interpolate({
         inputRange: [-SCREEN_WIDTH, 0, SCREEN_WIDTH],
         outputRange: ['-70deg', '0deg', '70deg']
      });

      return {
         ...this.position.getLayout(),
         transform: [{ rotate }]
      };
   }

   renderCards() {
      return this.props.data.map((item, index) => {
         //wrap the first card inside the animated view with pan responder events attached and the layout connected to animated XY value
         if (index == 0) {
            return (
               <Animated.View
                  key={index}
                  style={this.getCardStyle()}
                  {...this.panResponder.panHandlers}
               >
                  {this.props.renderCard(item)}
               </Animated.View>
            )
         }

         return this.props.renderCard(item);
      });
   }

   render() {
      return (
         <View>
            {this.renderCards()}
         </View>
      );
   }
};