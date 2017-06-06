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
         headerHeight: undefined,
         bodyHeight: undefined
      }

      this.height = new Animated.Value(undefined)

      this.toggle = this.toggle.bind(this);
      this.setInitHeight = this.setInitHeight.bind(this);
      this.onHeaderLayout = this.onHeaderLayout.bind(this);
      this.onBodyLayout = this.onBodyLayout.bind(this);
   }

   toggle() {
      const { headerHeight, bodyHeight, expanded } = this.state;

      let targetHeight = expanded ? headerHeight : headerHeight + bodyHeight;
      let targetRotation = expanded ? '0deg' : '180deg';

      this.setState({
         expanded: !expanded
      });

      Animated.timing(
         this.height,
         {
            toValue: targetHeight,
            duration: 2000,
            easing: Easing.inOut(Easing.cubic)
         }).start();
   }

   setInitHeight() {
      const { headerHeight, bodyHeight, expanded } = this.state;

      if (!headerHeight || !bodyHeight)
         return;

      const initHeight = expanded ? headerHeight + bodyHeight : headerHeight;
      this.height.setValue(initHeight)
      this.forceUpdate();
   }

   onHeaderLayout(event) {
      if (this.state.headerHeight)
         return;

      this.setState({
         headerHeight: event.nativeEvent.layout.height
      }, this.setInitHeight);
   }

   onBodyLayout(event) {
      if (this.state.bodyHeight)
         return;

      this.setState({
         bodyHeight: event.nativeEvent.layout.height
      }, this.setInitHeight);
   }

   render() {
      return (
         <Animated.View style={[styles.container, { height: this.height }]}>
            <TouchableWithoutFeedback onPress={this.toggle} onLayout={this.onHeaderLayout}>
               <View style={styles.bar}>
                  <Text style={styles.title}>{this.props.title}</Text>

                  <Animated.View style={[styles.arrow, { transform: [{ rotate: '180deg' }] }]}>
                     <View style={styles.arrowBottom} />
                  </Animated.View>
               </View>
            </TouchableWithoutFeedback>

            {/*{this.state.expanded &&*/}
            <View style={styles.body} onLayout={this.onBodyLayout}>
               {this.props.children}
            </View>
            {/*}*/}

         </Animated.View>
      );
   }
}

var styles = StyleSheet.create({
   container: {
      overflow: 'hidden',
      backgroundColor: 'transparent'
   },

   bar: {
      flexDirection: 'row',
      alignItems: 'center',
      backgroundColor: '#c0c0c0',
      padding: 10
   },
   body: {
      backgroundColor: '#fff',
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