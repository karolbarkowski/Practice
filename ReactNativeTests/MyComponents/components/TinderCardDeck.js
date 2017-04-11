import React from 'react';
import { View, Animated, PanResponder, Dimensions } from 'react-native';

const SCREEN_WIDTH = Dimensions.get('window').width;

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
         onPanResponderRelease: () => { this.resetPosition(); }
      });
   }

   handleResponderMove(gesture) {
      this.position.setValue({ x: gesture.dx, y: gesture.dy });
   }

   resetPosition() {
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