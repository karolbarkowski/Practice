import React from 'react';
import { StackNavigator } from 'react-navigation';

import Index from './index';

//components
import PanelCollapsibleTest from './componentTests/PanelCollapsibleTest';
import PanelLogTest from './componentTests/PanelLogTest';
import TinderCardTest from './componentTests/TinderCardTest';

//animations
import AnimationBasic from './animationTests/AnimationBasic';


export default class Main extends React.Component {
   render() {
      const BasicApp = StackNavigator({
         Index: { screen: Index },
         PanelCollapsibleTest: { screen: PanelCollapsibleTest },
         PanelLogTest: { screen: PanelLogTest },
         TinderCardTest: { screen: TinderCardTest },
         AnimationBasic: { screen: AnimationBasic }
      });

      return <BasicApp />;
   }
};

