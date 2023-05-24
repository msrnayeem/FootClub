import DashboardIcon from '../assets/icons/dashboard.svg';
import ShippingIcon from '../assets/icons/shipping.svg';
import UserIcon from '../assets/icons/user.svg';

const sidebar_menu = [
    
    {
        id: 1,
        icon: DashboardIcon,
        path: '/Home',
        title: 'Home',
    },
    {
        id: 2,
        icon: UserIcon,
        path: '/profile',
        title: 'Profile',
    },
    {
        id: 3,
        icon: UserIcon,
        path: '/players',
        title: 'Players',
    },
    {
        id: 4,
        icon: ShippingIcon,
        path: '/admins',
        title: 'admins',
    },
    {
        id: 5,
        icon: ShippingIcon,
        path: '/customers',
        title: 'customers',
    },
    {
        id: 6,
        icon: ShippingIcon,
        path: '/addplayer',
        title: 'Add Player',
    },

    {
        id: 7,
        icon: ShippingIcon,
        path: '/orders',
        title: 'Orders',
    }
   
]

export default sidebar_menu;