import { NotFound } from "./components/exceptions/NotFound";
import { EditEvent } from "./components/pages/events/EditEvent";
import { Events } from "./components/pages/events/Events";
import { Home } from "./components/pages/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/events',
    element: <Events />
  },
  {
    path: '/events/:id',
    element: <EditEvent />
  },
  {
    path: '*',
    element: <NotFound/>
  }
];

export default AppRoutes;