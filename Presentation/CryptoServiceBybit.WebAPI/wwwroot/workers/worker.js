export class Worker {
    constructor(callback, requestFunction, timeoutMs) {
        this.m_isRun = false;
        this.m_isStopWorker = true;

        this.m_callback = callback;
        this.m_requestFunction = requestFunction;
        this.m_timeoutMs = timeoutMs || 5000;
    }

    runWorker() {
        this.m_isRun = true;
        this.m_isStopWorker = false;

        setTimeout(this.work.bind(this), this.m_timeoutMs);
    }

    stopWorker() {
        this.m_isRun = false;
        this.m_isStopWorker = true;
    }

    work() {
        this.m_callback("WORK");
        if (this.m_isRun) {
            setTimeout(this.work.bind(this), this.m_timeoutMs);
        }
    }
}