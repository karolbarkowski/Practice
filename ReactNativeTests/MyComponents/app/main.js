import React from 'react';
import { StackNavigator } from 'react-navigation';

import Index from './index';

//components
import PanelCollapsibleTest from './componentTests/PanelCollapsibleTest';
import PanelLogTest from './componentTests/PanelLogTest';
import TinderCardTest from './componentTests/TinderCardTest';

//animations
import AnimationBasic from './animationTests/AnimationBasic';

//navigation
import TabsTest from './navigationTests/TabsTest';


export default class Main extends React.Component {
   render() {
      const routeConfigs = {
         Index: {
            screen: Index,
            navigationOptions: {
               headerVisible: false,
            }
         },
         PanelCollapsibleTest: {
            screen: PanelCollapsibleTest,
            navigationOptions: {
               title: 'Collapsible Panel Test',
               headerVisible: false,
            }
         },
         PanelLogTest: {
            screen: PanelLogTest,
            navigationOptions: {
               title: 'Log Panel Test',
            }
         },
         TinderCardTest: {
            screen: TinderCardTest,
            navigationOptions: {
               title: 'Tinder Cards Test',
            }
         },
         AnimationBasic: {
            screen: AnimationBasic,
            navigationOptions: {
               title: 'Basic Animation',
            }
         },
         TabsTest: {
            screen: TabsTest,
            navigationOptions: {
               title: 'Tabbed Layout Test',
            }
         },
      };

      const stackNavigatorConfig = {
         headerMode: 'screen'
      };

      const BasicApp = StackNavigator(routeConfigs, stackNavigatorConfig);

      return <BasicApp />;
   }
};

