import React from 'react';
import {
   StyleSheet,
   Text,
   View,
   TouchableHighlight,
   TouchableWithoutFeedback
} from 'react-native';
import * as Animatable from 'react-native-animatable';
import { PanelLog } from './ComponentsIndex';



export default class PanelCollapsible extends React.Component {
   constructor(props) {
      super(props);

      this.state = {
         expanded: true,
         maxBodyHeight: null
      }

      this.toggle = this.toggle.bind(this);
      this.onBodyLayout = this.onBodyLayout.bind(this);
   }

   toggle() {
      let duration = this.props.duration;
      let easing = 'linear';
      let targetHeight = this.state.expanded ? 0 : this.state.maxBodyHeight;
      let targetRotation = this.state.expanded ? '0deg' : '180deg';

      this.refs.body.transitionTo({ height: targetHeight }, duration, easing);
      this.refs.arrow.transitionTo({ transform: [{ rotate: targetRotation }] }, duration, easing);

      this.setState({
         expanded: !this.state.expanded
      });
   }

   onBodyLayout(event) {
      if (this.state.maxBodyHeight)
         return;

      this.setState({
         maxBodyHeight: event.nativeEvent.layout.height
      })
   }

   // _handleLayoutChange(event) {
   //    const contentHeight = event.nativeEvent.layout.height;
   //    if (this.state.animating || this.props.collapsed || this.state.measuring || this.state.contentHeight === contentHeight) {
   //       return;
   //    }
   //    // this.state.height.setValue(contentHeight);
   //    // this.setState({ contentHeight });

   //    this.context.log(contentHeight);
   // };


   render() {
      return (
         <View style={styles.container}>
            <TouchableWithoutFeedback onPress={this.toggle}>
               <View style={[styles.bar, { padding: this.props.padding }]}>
                  <Text style={styles.title}>{this.props.title}</Text>

                  <Animatable.View ref="arrow" style={[styles.arrow, { transform: [{ rotate: '180deg' }] }]}>
                     <View style={styles.arrowBottom} />
                  </Animatable.View>
               </View>
            </TouchableWithoutFeedback>

            <Animatable.View ref="body" style={[styles.body]} onLayout={this.onBodyLayout}>
               <View style={[styles.bodyInner, { padding: this.props.padding }]}>
                  {this.props.children}
               </View>
            </Animatable.View>
         </View>
      );
   }
}

PanelCollapsible.defaultProps = {
   padding: 10,
   duration: 150
};

PanelCollapsible.propTypes = {
   title: React.PropTypes.string,
   padding: React.PropTypes.number,
   duration: React.PropTypes.number
};

// PanelCollapsible.contextTypes = {
//    log: React.PropTypes.func
// };


var styles = StyleSheet.create({
   container: {
      width: '100%'
   },

   bar: {
      flexDirection: 'row',
      alignItems: 'center',
      backgroundColor: '#c0c0c0'
   },
   body: {
      backgroundColor: '#fff'
   },
   bodyInner: {
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