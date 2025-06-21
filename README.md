# ChatApp

[지원 포지션: Toss 백엔드 서버 개발자](https://toss.im/career/job-detail?job_id=6600650003)

**ChatApp**은 Toss의 백엔드 서버 개발자 포지션 지원을 위해 제작한 포트폴리오 프로젝트입니다.  
gRPC 및 MagicOnion에 대한 이해를 바탕으로, 실제 사용 가능한 클라이언트-서버 구조를 설계하고 구현했습니다.

.NET 환경에서 **ASP.NET Core 기반의 gRPC 서버**, **Avalonia UI 클라이언트**, **SQLite 기반 데이터 저장소**로 구성되어 있으며,  
계층 분리 및 유지보수에 용이한 구조를 구현했습니다.

### 🧠 아키텍처 개요

- MagicOnion은 C# 친화적인 gRPC 프레임워크로, 인터페이스 기반 RPC 구현이 가능합니다.
- HTTP보다 빠른 gRPC 통신을 통해 클라이언트와 서버가 실시간에 가깝게 소통합니다.

> ✅ 현재는 회원가입 기능까지 구현되어 있으며, 향후 로그인/채팅 기능이 확장될 예정입니다.  
> 🎥 시연 영상은 GIF 형태로 업로드 예정입니다.

---

## 🚀 실행 방법

1. 레포지토리 클론
```bash
  git clone https://github.com/waterpare833/chat-app.git
  cd chat-app
```

2. 서버 실행 (Docker Compose)
```bash
  docker-compose up
```
3. 클라이언트 실행
- [Releases 페이지](https://github.com/waterpare833/chat-app/releases)에서 Avalonia 클라이언트 ZIP 다운로드
- 압축 해제 후 `Client.exe` 실행

---

## ⚙️ 기술 스택

- **C# / .NET 9**
- **ASP.NET Core** – 백엔드 서버
- **MagicOnion (gRPC)** – 고성능 RPC 통신
- **SQLite** – 로컬 데이터 저장
- **Avalonia UI** – 클라이언트 UI
- **Docker / GitHub Container Registry** – 컨테이너 배포
- **xUnit** – 단위 테스트

---

## ✅ 현재 구현된 기능

- 사용자 회원가입
- SQLite에 사용자 정보 저장
- gRPC 서버-클라이언트 통신 구현
- 저장소 단위 테스트 작성

> 🔜 향후 구현 예정 기능:
> - 로그인
> - 채팅 메시지 송/수신

---

## 🐳 Docker 정보

- 이미지: `ghcr.io/waterpare833/chat-app/db:latest`
- Docker 기반으로 로컬에서 손쉽게 서버 실행 가능

---

## 📎 관련 링크

- 🔗 [Toss 채용 공고](https://toss.im/career/job-detail?job_id=6600650003)
- 📦 [GitHub Repository](https://github.com/waterpare833/chat-app)
- 🧊 [Docker Image (DB)](https://github.com/users/waterpare833/packages/container/package/chat-app%2Fdb)
- 🖥️ [Avalonia 클라이언트 릴리스](https://github.com/waterpare833/chat-app/releases)