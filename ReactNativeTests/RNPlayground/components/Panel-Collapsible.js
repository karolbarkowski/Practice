import React from 'react';
import { StyleSheet, Text, View, TouchableHighlight, TouchableWithoutFeedback, Animated, Easing } from 'react-native';


export default class PanelCollapsible extends React.Component {
   static defaultProps = {
      title: "",
      expanded: true
   }

   static propTypes = {
      title: React.PropTypes.string,
      expanded: React.PropTypes.bool
   }

   constructor(props) {
      super(props);

      this.state = {
         title: props.title,
         expanded: props.expanded,
         isInitialized: false
      }

      //keep these two outside the state so setting these values won't rerender the view
      this.bodyHeight = undefined;

      //this could potentially be a part of state as well but my way of doing things is to keep animated values out of state
      //as they are not directly related with the component state
      this.height = new Animated.Value(undefined)

      //set 'this' bindings
      this.toggle = this.toggle.bind(this);
      this.onBodyLayout = this.onBodyLayout.bind(this);
   }

   toggle() {
      console.log('toggle');
      const { expanded } = this.state;

      let targetHeight = expanded ? 0 : this.bodyHeight;
      let targetRotation = expanded ? '0deg' : '180deg';

      this.setState({
         expanded: !expanded
      });

      Animated.timing(
         this.height,
         {
            toValue: targetHeight,
            duration: 500,
            easing: Easing.inOut(Easing.cubic)
         }).start();
   }

   onBodyLayout(event) {

      if (this.bodyHeight)
         return;

      console.log('onBodyLayout');
      this.bodyHeight = event.nativeEvent.layout.height;

      const { expanded } = this.state;
      const initHeight = expanded ? event.nativeEvent.layout.height : 0;
      console.log('Init height is: ', initHeight);
      this.height.setValue(initHeight)
   }


   render() {
      console.log('render with height ', this.height._value);
      return (
         <View style={styles.container}>
            <TouchableWithoutFeedback onPress={this.toggle}>
               <View style={styles.bar}>
                  <Text style={styles.title}>{this.props.title}</Text>

                  <Animated.View style={[styles.arrow, { transform: [{ rotate: '180deg' }] }]}>
                     <View style={styles.arrowBottom} />
                  </Animated.View>
               </View>
            </TouchableWithoutFeedback>

            <View style={[styles.body, { height: this.state.expanded ? this.bodyHeight : 0 }]} >
               <View onLayout={this.onBodyLayout}>
                  {this.props.children}
               </View>
            </View>
            <View styler={styles.bodyHidden}>
               {this.props.children}
            </View>
         </View>
      );
   }
}

var styles = StyleSheet.create({
   container: {
      backgroundColor: 'transparent',
   },

   bar: {
      flexDirection: 'row',
      alignItems: 'center',
      backgroundColor: '#c0c0c0',
      padding: 10
   },
   body: {
      backgroundColor: 'red',
   },
   bodyHidden: {
         position: 'absolute',
      bottom: 0,
      left: 0,
      backgroundColor: 'green'
   },


   title: {
      flex: 1,
      color: '#2a2f43',
      fontSize: 21
   },

   arrow: {
      width: 12,
      height: 20,
      paddingTop: 7
   },
   arrowBottom: {
      width: 0,
      height: 0,
      borderTopWidth: 10,
      borderTopColor: '#2a2f43',
      borderLeftColor: 'transparent',
      borderLeftWidth: 6,
      borderRightColor: 'transparent',
      borderRightWidth: 6
   }
});