import React from 'react';
import { View, StyleSheet, Animated, Alert, Dimensions } from 'react-native';
import Ball from './../../componentsDev/ball';

let { height, width } = Dimensions.get('window');
let ballSize = 60;

export default class AnimationBasic extends React.Component {
   animateDown() {
      let _self = this;

      Animated.spring(this.position, {
         toValue: { x: width - ballSize - 50, y: height - ballSize - 50 }
      }).start(() => {
         //callback at the end
         _self.animateUp();
      });
   }

   animateUp() {
      let _self = this;
      Animated.spring(this.position, {
         toValue: { x: 50, y: 50 }
      }).start(() => {
         //callback at the end
         _self.animateDown();
      });
   }

   componentWillMount() {
      this.position = new Animated.ValueXY({ x: 50, y: 50 });
      this.animateDown();
   }

   render() {
      return (
         <View>
            <Animated.View style={this.position.getLayout()}>
               <Ball />
            </Animated.View>
         </View>
      )
   }
}
