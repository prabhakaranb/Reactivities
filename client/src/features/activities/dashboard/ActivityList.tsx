import { Box } from "@mui/material";
import ActivityCard from "./ActivityCard";

type Props = {
  activities: Activity[];
  selectActivity: (id: string) => void;
};

export default function ActivityList({activities, selectActivity}: Props) {
  if (!activities || activities.length === 0) {
    return <Box sx={{ textAlign: 'center', mt: 5 }}>No activities found.</Box>;
  }

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', gap: 3 }}>
        {activities.map((activity) => (
            <ActivityCard 
              key={activity.id} 
              activity={activity} 
              selectActivity={selectActivity}
            />
        ))}
    </Box>
  )
}
