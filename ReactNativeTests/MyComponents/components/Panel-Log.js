import React from 'react';
import { StyleSheet, Text, View, ScrollView, Dimensions } from 'react-native';

let _messages = [];
let _instance = null;
let _maxMessagesCount = 15;


export default class PanelLog extends React.Component {
   componentWillMount() {
      //don't do tihs in constructor as the constructor is not fired during hot reload which causes the panel to lose reference to a component intance
      //doing this in here will overcome this
      _instance = this;
      _maxMessagesCount = this.props.maxMessagesCount;
   }

   static Log(message) {
      _messages.push(message);

      if (_messages.length > 12) {
         _messages.shift();
      }
      _instance.forceUpdate();
   }

   static Clear() {
      _messages.clear();
      _instance.forceUpdate();
   }

   render() {
      return (
         <View>
            <View style={styles.container}>
               <ScrollView ref={ref => this.scrollView = ref}
                  onContentSizeChange={(contentWidth, contentHeight) => {
                     this.scrollView.scrollToEnd({ animated: true });
                  }}>
                  {_messages.map(function (name, index) {
                     return <Text style={styles.message} key={index}>{name}</Text>;
                  })}
               </ScrollView>
            </View>
         </View>
      );
   }
}

PanelLog.defaultProps = {
   maxMessagesCount: 20
};

PanelLog.propTypes = {
   position: React.PropTypes.oneOf(['top', 'bottom']),
   maxMessagesCount: React.PropTypes.number
};

var styles = StyleSheet.create({
   container: {
      width: '100%',
      position: 'absolute',
      top: 0,
      padding: 5,
      height: Dimensions.get('window').height / 4,
      backgroundColor: 'black',
      zIndex: 10,
      opacity: 0.8
   },
   message: {
      color: '#00FF00',
      fontSize: 10
   }
});