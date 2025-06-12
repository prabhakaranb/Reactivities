import Typography from '@mui/material/Typography';
import { Observer } from 'mobx-react-lite'
import { useStore } from "../../lib/hooks/useStore";

export default function Counter() {
  const { counterStore } = useStore();

  return (
    <Observer>
        {() => (
            <>
            <Typography variant="h4" gutterBottom>{counterStore.title}</Typography>
            <Typography variant="h6">The count is: {counterStore.count}</Typography>
            </>
        )}
    </Observer>
  )
}