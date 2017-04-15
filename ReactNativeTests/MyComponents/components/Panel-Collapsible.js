import React from 'react';
import { StyleSheet, Text, View, TouchableHighlight, TouchableWithoutFeedback, Animated, Easing } from 'react-native';


export default class PanelCollapsible extends React.Component {
   constructor(props) {
      super(props);

      this.state = {
         title: props.title,
         expanded: true,
         maxBodyHeight: null
      }

      this.height = new Animated.Value(0);

      this.toggle = this.toggle.bind(this);
      this.onBodyLayout = this.onBodyLayout.bind(this);
   }

   toggle() {
      let targetHeight = this.state.expanded ? 0 : this.state.maxBodyHeight;
      // let targetRotation = this.state.expanded ? '0deg' : '180deg';

      this.setState({
         expanded: !this.state.expanded
      });

      // this.height.setValue(initialValue);  //Step 3
      Animated.timing(
         this.height,
         {
            toValue: targetHeight,
            duration: 200
         }).start();  //Step 5
   }

   onBodyLayout(event) {
      if (this.state.maxBodyHeight)
         return;

      this.setState({
         maxBodyHeight: 100//event.nativeEvent.layout.height
      });
      this.height.setValue(event.nativeEvent.layout.height);
   }

   render() {
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

            <Animated.View style={[styles.body, { height: this.height }]}>
               <View style={styles.bodyInner} onLayout={this.onBodyLayout}>
                  {this.props.children}
               </View>
            </Animated.View>
         </View>
      );
   }
}

PanelCollapsible.defaultProps = {
   title: ""
};

PanelCollapsible.propTypes = {
   title: React.PropTypes.string
};

var styles = StyleSheet.create({
   container: {
      width: '100%'
   },

   bar: {
      flexDirection: 'row',
      alignItems: 'center',
      backgroundColor: '#c0c0c0',
      padding: 10
   },
   body: {
      backgroundColor: '#fff'
   },
   bodyInner: {
      padding: 10
   },


   title: {
      flex: 1,
      color: '#2a2f43',
      fontSize: 21
   },

   arrow: {
      width: 16,
      height: 24,
      paddingTop: 6
   },
   arrowBottom: {
      width: 0,
      height: 0,
      borderTopWidth: 15,
      borderTopColor: '#2a2f43',
      borderLeftColor: 'transparent',
      borderLeftWidth: 8,
      borderRightColor: 'transparent',
      borderRightWidth: 8
   }
});