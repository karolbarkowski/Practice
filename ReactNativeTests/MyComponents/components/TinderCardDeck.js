import React from 'react';
import { View, Animated, PanResponder } from 'react-native';

export default class TinderCardDeck extends React.Component {
   constructor(props) {
      super(props);
      const _self = this;

      this.position = new Animated.ValueXY();

      this.panResponder = PanResponder.create({
         //executed anytime user taps on the screen, if true is returned then this inscance of pan responder will handle the tap event
         onStartShouldSetPanResponder: () => true,

         //once the responder is handling the gesture, this is the callback function of that gesture, called many times as long as user is dragging
         onPanResponderMove: (event, gesture) => {
            _self.position.setValue({ x: gesture.dx, y: gesture.dy });
         },

         //executed when lets go the screen
         onPanResponderRelease: () => { }
      });
   }

   getCardStyle() {
      const position = this.position;
      const rotate = position.x.interpolate({
         inputRange: [-500, 0, 500],
         outputRange: ['-120deg', '0deg', '120deg']
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