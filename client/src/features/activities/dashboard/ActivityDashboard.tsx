import { Grid2 } from "@mui/material";
import ActivityList from "./ActivityList";
import ActivityDetail from "../details/ActivityDetail";
import ActivityForm from "../form/ActivityForm";

type Props = {
  activities: Activity[]
  selectActivity: (id: string) => void
  cancelSelectActivity: () => void
  selectedActivity?: Activity | undefined
  openForm: (id?: string) => void
  closeForm: () => void
  editMode: boolean,
  submitForm: (activity: Activity) => void
  deleteActivity: (id: string) => void
}

export default function ActivityDashboard({
  activities,
  selectActivity,
  cancelSelectActivity,
  selectedActivity,
  openForm,
  closeForm,
  editMode,
  submitForm,
  deleteActivity
}: Props) {
  return (
    <Grid2 container spacing={2} sx={{ marginTop: 3 }}>
      <Grid2 size={7}>
        <ActivityList
          activities={activities}
          selectActivity= {selectActivity} 
          deleteActivity={deleteActivity}
        />
      </Grid2>
      <Grid2 size={5}>
        {selectedActivity && !editMode &&
          <ActivityDetail
            activity={selectedActivity} 
            cancelSelectActivity={cancelSelectActivity}
            openForm={openForm}
          />
        }
        {editMode &&
          <ActivityForm 
            activity={selectedActivity} 
            closeForm={closeForm}
            submitForm={submitForm}           
          />
        }
      </Grid2>
    </Grid2>
  );
}
