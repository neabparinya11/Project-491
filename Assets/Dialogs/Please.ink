INCLUDE GlobalVariables.ink

-> Main
=== Main ===
แพรว: …

{playerName} : แพรว!

แพรว: แกมาที่นี่ได้ไง

{playerName} : ฉันเห็นในไดอารี่ของแก

แพรว: แกเห็นมันแล้วหรอ

{playerName} : ใช่

แพรว: แล้วแกมาทำอะไรที่นี่

แพรว: กลับไปเถอะ{playerName} อย่ามายุ่งกับฉันเลย

-> Choice

=== Choice ===
+[โอเค…]
{playerName} : โอเค…
 ~bad_end = true
 ->END

+[ไม่]
->Continue

=== Continue ===

{playerName} : ไม่ ฉันไม่กลับ
แพรว: ฉันไม่อยากทำแกเสียเวลาไปกว่านี้แล้ว{playerName} 

แพรว: ฉันขอร้องนะ

แพรว: แกกลับบ้านไปเถอะ ฉันไม่อยากให้แกมาเสียเวลากับคนแบบฉันอีก

-> Choice2

=== Choice2 ===
+[(เดินหนี)]
{playerName} : …
 ~bad_end = true
 ->END


+[(ขอโทษ)]

->Continue2

=== Continue2 ===

{playerName} : ฉันขอโทษที่พูดแบบนั้นออกไป

{playerName} : ฉันไม่รู้จริง ๆ ว่าแกเจอปัญหาอะไรมา

แพรว: แกจะไปรู้อะไร

แพรว: สิ่งที่ฉันเจอ มันมากกว่าในไดอารี่อีกนะ

แพรว: แกคิดว่าแกอ่านแค่นั้นแล้วแกจะเข้าใจฉันหรอ

แพรว: นั่นมันไม่ถึงครึ่งนึงของความเจ็บปวดของฉันด้วยซ้ำ

แพรว: ฉันไม่อยากอยู่แล้ว

แพรว: ปล่อยฉันตายเถอะนะ

-> Choice3

=== Choice3 ===

+[ ฉันอยู่ตรงนี้แล้ว]
->Continue3

+[ไม่สงสารพ่อแม่หรอ]
{playerName} : ทำแบบนี้ไม่สงสารพ่อแม่หรอ
 ~bad_end = true
 ->END

=== Continue3 ===
{playerName} : ใจเย็น ๆ ฉันอยู่ตรงนี้แล้ว

แพรว: ฉันมันไร้ค่า ขี้แพ้ น่าสมเพช

แพรว: ฉันเป็นตัวปัญหาให้ทุก ๆ คนเลย

{playerName} : ไม่จริง

-> Choice4

=== Choice4 ===

+[ฉันเข้าใจแกนะ]

->Continue4

+[คนอื่นลำบากกว่านี้] 
{playerName} : ยังมีคนที่ลำบากกว่าแกเยอะแยะเลย
 ~bad_end = true
 ->END

=== Continue4 ===

{playerName} : ฉันเข้าใจแกนะแพรว

แพรว: (ร้องไห้)

แพรว: แกจะมาเข้าใจฉันได้ยังไง

แพรว: แกไม่ใช่ฉัน

แพรว: ไม่ใช่คนป่วยแบบฉันด้วยซ้ำ

-> Choice5

=== Choice5 ===
+[สู้ ๆ นะ] 
{playerName} : สู้ ๆ นะ
 ~bad_end = true
 ->END

+[ใจเย็น ๆ ก่อน]
{playerName} : ใจเย็น ๆ ก่อนนะแพรว

{playerName} : โอเค ฉันคงไม่เข้าใจแกจริง ๆ

{playerName} : แต่ฉันจะอยู่ข้าง ๆ แกนะ

{playerName} : ฉันจะอยู่ตรงนี้ รอรับฟังแก 

{playerName} : เราผ่านมันไปด้วยกันนะแพรว

แพรว: {playerName} 

-> Choice6

=== Choice6 ===

+[(กอดแพรว)]
{playerName} : (เดินเข้าไปกอดแพรว)

-> END

+[(ยืนรอ)]

->Continue6

=== Continue6 ===


-> END

