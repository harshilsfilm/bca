<html>
<head>
    <title>Cookie & Session Demo</title>
</head>
<body>
    <h2>Enter Your Name</h2>

    <form action="CookieSessionServlet" method="post">
        Name: <input type="text" name="uname" required>
        <br><br>
        <input type="submit" value="Submit">
    </form>
</body>
</html>
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.*;

public class CookieSessionServlet extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        response.setContentType("text/html");
        PrintWriter out = response.getWriter();

        String name = request.getParameter("uname");

        // ---------------- COOKIE ----------------
        Cookie ck = new Cookie("username", name);
        ck.setMaxAge(60 * 60); // 1 hour
        response.addCookie(ck);

        // ---------------- SESSION ----------------
        HttpSession session = request.getSession();
        Integer count = (Integer) session.getAttribute("count");

        if (count == null) {
            count = 1;
        } else {
            count++;
        }
        session.setAttribute("count", count);

        // ---------------- OUTPUT ----------------
        out.println("<html><body>");
        out.println("<h2>Cookie & Session Example</h2>");
        out.println("<h3>Welcome: " + name + "</h3>");
        out.println("<h3>Session Visit Count: " + count + "</h3>");
        out.println("<a href='display.jsp'>Go to Display Page</a>");
        out.println("</body></html>");
    }
}
<%@ page import="javax.servlet.http.*" %>
<html>
<head>
    <title>Display Page</title>
</head>
<body>

<h2>Reading Cookie & Session</h2>

<%
    // Read Cookie
    Cookie[] cookies = request.getCookies();
    String uname = "Guest";

    if (cookies != null) {
        for (Cookie c : cookies) {
            if (c.getName().equals("username")) {
                uname = c.getValue();
            }
        }
    }

    // Read Session
    Integer count = (Integer) session.getAttribute("count");
%>

<h3>Username from Cookie: <%= uname %></h3>
<h3>Session Count: <%= count %></h3>

</body>
</html>
