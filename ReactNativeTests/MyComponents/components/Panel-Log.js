import React from 'react';
import { StyleSheet, Text, View, ScrollView, Dimensions, Animated, PanResponder } from 'react-native';


export default class PanelLog extends React.Component {
   constructor(props) {
      super(props);
      const _self = this;

      this.state = {
         messages: []
      };

      this.position = new Animated.ValueXY(0, 0);
      this.scale = new Animated.Value(1);

      this.panResponder = PanResponder.create({
         onMoveShouldSetResponderCapture: () => true,
         onMoveShouldSetPanResponderCapture: () => true,

         onPanResponderGrant: (e, gestureState) => {
            Animated.spring(
               this.scale,
               { toValue: 1.1, friction: 6, tension: 300 }
            ).start();
         },

         onPanResponderMove: (event, gesture) => {
            _self.position.setValue({ x: 0, y: gesture.dy });
         },

         onPanResponderRelease: (e, gestureState) => {
            this.position.setOffset({ x: this.currentPanValue.x, y: this.currentPanValue.y });
            this.position.setValue({ x: 0, y: 0 });

            Animated.spring(
               this.scale,
               { toValue: 1.0, friction: 6, tension: 300 }
            ).start();
         }
      });
   }


   Log(message) {
      var _messages = this.state.messages.concat([message]);
      if (_messages.length > this.props.maxMessagesCount) {
         _messages.shift();
      }

      this.setState({ messages: _messages });
   }

   Clear() {
      this.setState({ messages: [] });
   }

   componentDidMount() {
      this.currentPanValue = { x: 0, y: 0 };
      this.panListener = this.position.addListener((value) => {
         this.currentPanValue = value;
      })
   }

   componentWillUnmount() {
      this.position.removeListener(this.panListener);
   }

   render() {
      const _self = this;

      return (
         <Animated.View
            style={[
               styles.container,
               this.position.getLayout(),
               { transform: [{ scale: this.scale }] },
               this.props.containerStyle
            ]}

         >
            <ScrollView
               style={[styles.list, this.props.listStyle]}
               ref={ref => this.scrollView = ref}
               onContentSizeChange={(contentWidth, contentHeight) => {
                  this.scrollView.scrollToEnd({ animated: true });
               }}>
               {this.state.messages.map(function (name, index) {
                  return <Text style={[styles.message, _self.props.messageStyle]} key={index}>{name}</Text>;
               })}
            </ScrollView>
            <View
               style={[
                  styles.dragger,
                  this.props.draggerStyle
               ]}
               {...this.panResponder.panHandlers}
            ></View>
         </Animated.View>
      );
   }
}

PanelLog.defaultProps = {
   maxMessagesCount: 20
};

PanelLog.propTypes = {
   maxMessagesCount: React.PropTypes.number
};

var styles = StyleSheet.create({
   container: {
      flexDirection: 'row',
      width: '100%',
      position: 'absolute',
      height: Dimensions.get('window').height / 4,
      backgroundColor: 'black',
      zIndex: 10,
      opacity: 0.8
   },
   list: {
      flex: 1,
      padding: 5
   },
   dragger: {
      width: 40,
      backgroundColor: '#2D2D2D',
      borderLeftWidth: 1,
      borderLeftColor: '#494949'
   },
   message: {
      color: '#00FF00',
      fontSize: 10
   }
});