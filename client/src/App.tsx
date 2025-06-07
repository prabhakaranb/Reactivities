import { List, ListItem, ListItemText, Typography } from '@mui/material';
import axios from 'axios';
import { useEffect, useState} from 'react'

function App() {
  const title = 'Reactivities'
  const [activities, setActivities] = useState<Activity[]>([])

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5002/api/activities')
      .then(response => setActivities(response.data))
      .catch(error => console.error('Error fetching activities:', error));

      // Cleanup function to avoid memory leaks
      // Not strictly necessary here, but good practice in case of subscriptions or intervals
      return () => {}
  }, []);

  return (
    <>
      <Typography variant='h3' component='h3' gutterBottom>
        Welcome to {title}
      </Typography>
      <List>
        {activities.map(activity => (
          <ListItem>
              <ListItemText primary={activity.title} />
            </ListItem>
        ))}
      </List>
    </>
  )
}

export default App
