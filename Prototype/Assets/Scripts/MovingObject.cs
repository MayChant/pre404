using System.Collections;
using UnityEngine;

public abstract class MovingObject : LevelElement {

    public float moveTime = 0.1f;
    public LayerMask blockingLayer;
    public bool moved = false;
    public float tileSize = 0.64f;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;

	// Use this for initialization
	protected virtual void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = tileSize / moveTime;
	}

    protected bool Move (float xDir, float yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            //StartCoroutine(SmoothMovement(end));
			
			// If the current position is lurker: change it to wall but a different icon
			// if (transform.position.??? == lurker???) {
			//		GameObject lurker = Instantiate(lurkerTile, new Vector3(getLeftBound() + transform.position.x??? * tileSize, getUpperBound() + transform.position.y??? * tileSize, 0f), Quaternion.identity, boardHolder);
			
            transform.Translate(new Vector3(xDir, yDir, 0f));
            moved = true;
            return true;
        }
        return false;
    }

    /*protected IEnumerator SmoothMovement (Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon) {
            print(inverseMoveTime);
            Vector2 newPosition = Vector2.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            print(sqrRemainingDistance);
            yield return null;
        }
    }*/

    protected virtual void AttemptMove<T>(int xDir, int yDir)
        where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
        {
            return;
        }
        T hitComponent = hit.transform.GetComponent<T>();
        
        if (!canMove && hitComponent != null)
        {
            return;
            //OnCantMove(hitComponent);
        }
    }
    /*protected abstract void OnCantMove<T>(T component)
        where T : Component;*/

    // Update is called once per frame
    void Update () {
		
	}
}
